if [ $1 == "build" ] ; then
 xbuild /property:GenerateFullPaths=true /p:Configuration=DebugNoDemo
elif [ $1 == "test" ] ; then
 mono ./packages/NUnit.ConsoleRunner.3.2.1/tools/nunit3-console.exe CronExpressionDescriptor.Test/bin/DebugNoDemo/CronExpressionDescriptor.Test.dll
fi